import Container from 'react-bootstrap/esm/Container';
import Row from 'react-bootstrap/esm/Row';
import Col from 'react-bootstrap/esm/Col';
import { Link, useNavigate } from 'react-router-dom';
import Form from 'react-bootstrap/Form';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useAuth } from '../../context/auth';
import { useCart } from '../../context/cart';
import Select from 'react-select';
import axios from 'axios';
import { useState, useEffect } from 'react';
import { CLIENT_ID } from '../../config/Config';
import { PayPalScriptProvider, PayPalButtons } from '@paypal/react-paypal-js';

import Item from './Item/Item';
import { faAngleLeft } from '@fortawesome/free-solid-svg-icons';
import classNames from 'classnames/bind';
import styles from './Pay.module.scss';

const cx = classNames.bind(styles);

function Pay() {
    const [auth] = useAuth();
    const [cart, setCart] = useCart();
    const navigate = useNavigate();

    const VND = new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });

    const [promotion, setPromotion] = useState([]);
    const [addresses, setAddresses] = useState([]);
    const [products, setProducts] = useState([]);
    const [order, setOrder] = useState({
        user: auth.user?._id,
        order: [],
        address: '',
        note: '',
        status: 'Pending',
        paymentType: '',
    });

    const [totalBill, setTotalBill] = useState(
        cart.cart?.cartDetails.reduce((total, item) => {
            return total + item.product.price * item.quantity;
        }, 0),
    );

    //paypal
    const [show, setShow] = useState(false);
    const [show2, setShow2] = useState(false);

    useEffect(() => {
        axios
            .get(`http://localhost:8080/api/address/${auth.user?._id}`)
            .then((res) => setAddresses(res.data.data[0].addresses))
            .catch((err) => console.log(err));
    }, [auth]);

    useEffect(() => {
        axios.get(`http://localhost:8080/api/product`).then((res) => {
            let data = res.data;
            let arr = [];
            cart.cart?.cartDetails.forEach((element) => {
                data.forEach((item) => {
                    if (element.product._id === item._id) {
                        item.quantity = element.quantity;
                        arr.push(item);
                    }
                });
            });
            setProducts(arr);
        });
    }, [cart]);

    const handleCheckout = (e) => {
        e.preventDefault();

        setOrder({
            ...order,
            user: auth.user?._id,
            order: products.map((item) => {
                return { product: item._id, quantity: item.quantity };
            }),
        });

        if (order.address === '') {
            alert('Bạn chưa chọn địa chỉ nhận hàng!');
            return;
        }

        if (order.paymentType === '') {
            alert('Bạn chưa chọn phương thức thanh toán!');
        } else if (order.paymentType === 'COD') {
            setShow2(true);
        } else {
            setShow(true);
            setTotalBill(
                products.reduce((total, product) => {
                    return (
                        total +
                        (product.promotion
                            ? (product.price * (100 - setDiscount(product.promotion))) / 100
                            : product.price) *
                            product.quantity
                    );
                }, 40000),
            );
        }
    };

    //Promotion
    useEffect(() => {
        axios
            .get('http://localhost:8080/api/promotion')
            .then((res) => {
                setPromotion(res.data);
            })
            .catch((err) => console.log(err));
    }, []);

    const setDiscount = (promotionID) => {
        const data = promotion.filter((promo) => {
            return promo._id === promotionID;
        });
        return data[0]?.discount;
    };

    const handleCheckoutCOD = (e) => {
        e.preventDefault();
        axios
            .post('http://localhost:8080/api/checkout', order)
            .then((res) => {
                alert('Thanh toán thành công!');
                setCart({});
                navigate('/');
            })
            .catch((err) => console.log(err));
    };

    return (
        <PayPalScriptProvider options={{ 'client-id': CLIENT_ID }}>
            <Container>
                <Row>
                    <Col xl={8}>
                        <h1>
                            <Link to="/" className={cx('pay-home')}>
                                Kidshop
                            </Link>
                        </h1>
                        <Row>
                            <Col>
                                <h3 className={cx('pay-lable')}>Thông tin nhận hàng</h3>
                                <Form>
                                    <Form.Group controlId="exampleForm.ControlInput1" className={cx('pay-form-group')}>
                                        <Form.Control
                                            type="text"
                                            value={`${auth.user?.firstName} ${auth.user?.lastName}`}
                                            className={cx('pay-input')}
                                            readOnly
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="exampleForm.ControlInput1" className={cx('pay-form-group')}>
                                        <Form.Control
                                            type="text"
                                            value={auth.user?.phone}
                                            className={cx('pay-input')}
                                            readOnly
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="exampleForm.ControlInput1" className={cx('pay-form-group')}>
                                        <Select
                                            placeholder="Địa chỉ"
                                            options={addresses}
                                            getOptionLabel={(option) => option.address}
                                            getOptionValue={(option) => option._id}
                                            className={cx('info-form-input')}
                                            onChange={(addresses) => setOrder({ ...order, address: addresses.address })}
                                        />
                                    </Form.Group>
                                    <Form.Group controlId="exampleForm.ControlInput1" className={cx('pay-form-group')}>
                                        <Form.Control
                                            as="textarea"
                                            placeholder="Ghi chú"
                                            rows={3}
                                            className={cx('pay-input')}
                                            name="note"
                                            value={order.note}
                                            onChange={(e) => setOrder({ ...order, note: e.target.value })}
                                        />
                                    </Form.Group>
                                </Form>
                            </Col>

                            <Col>
                                <h3 className={cx('pay-lable')}>Vận chuyển</h3>
                                <Form.Check
                                    type="radio"
                                    id="default-radio"
                                    label="Giao hàng tận nơi"
                                    className={cx('pay-radio')}
                                    checked
                                />
                                <h3 className={cx('pay-lable', 'mt-20')}>Thanh toán</h3>
                                <div
                                    className="mb-3"
                                    onChange={(e) => {
                                        setOrder({ ...order, paymentType: e.target.value });
                                        if (e.target.value === 'COD') {
                                            setShow(false);
                                        } else {
                                            setShow2(false);
                                        }
                                    }}
                                >
                                    <Form.Check
                                        type="radio"
                                        name="default-radio"
                                        value="COD"
                                        label="Thanh toán khi giao hàng (COD)"
                                        className={cx('pay-radio')}
                                    />
                                    <Form.Check
                                        type="radio"
                                        name="default-radio"
                                        value="Paypal"
                                        label="Thanh toán qua Paypal"
                                        className={cx('pay-radio')}
                                    />
                                </div>
                            </Col>
                        </Row>
                    </Col>
                    <Col xl={4} className={cx('pay-order')}>
                        <Row>
                            <h3 className={cx('pay-lable', 'mt-20')}>Đơn hàng</h3>
                            {products.map((product) => {
                                return (
                                    <Item
                                        key={product._id}
                                        id={product._id}
                                        url={product.productPic}
                                        name={product.name}
                                        size={product.size}
                                        color={product.color}
                                        price={
                                            product.promotion
                                                ? (product.price * (100 - setDiscount(product.promotion))) / 100
                                                : product.price
                                        }
                                        quantity={product.quantity}
                                    />
                                );
                            })}

                            <div className={cx('display-flex')}>
                                <p>Tạm tính</p>
                                <p>
                                    {VND.format(
                                        products.reduce((total, product) => {
                                            return (
                                                total +
                                                (product.promotion
                                                    ? (product.price * (100 - setDiscount(product.promotion))) / 100
                                                    : product.price) *
                                                    product.quantity
                                            );
                                        }, 0),
                                    )}
                                </p>
                            </div>
                            <div className={cx('display-flex')}>
                                <p>Phí vận chuyển</p>
                                <p>40.000đ</p>
                            </div>

                            <div className={cx('display-flex')}>
                                <p>Tổng cộng</p>
                                <p>
                                    {VND.format(
                                        products.reduce((total, product) => {
                                            return (
                                                total +
                                                (product.promotion
                                                    ? (product.price * (100 - setDiscount(product.promotion))) / 100
                                                    : product.price) *
                                                    product.quantity
                                            );
                                        }, 40000),
                                    )}
                                </p>
                            </div>
                            <div className={cx('display-flex')}>
                                <Link to="/cart">
                                    <button className={cx('pay-btn-back')}>
                                        <FontAwesomeIcon icon={faAngleLeft} /> Quay về giỏ hàng
                                    </button>
                                </Link>
                                <Link onClick={handleCheckout}>
                                    <button className={cx('pay-btn-buy')}>Thanh toán</button>
                                </Link>
                            </div>
                        </Row>
                        <Row>
                            {show ? (
                                <PayPalButtons
                                    createOrder={(data, actions) => {
                                        return actions.order.create({
                                            purchase_units: [
                                                {
                                                    amount: {
                                                        value: (totalBill / 23000).toFixed(1),
                                                    },
                                                },
                                            ],
                                        });
                                    }}
                                    onApprove={(data, actions) => {
                                        return actions.order.capture().then((details) => {
                                            const name = details.payer.name.given_name;
                                            alert(`Transaction completed by ${name}`);
                                            axios
                                                .post('http://localhost:8080/api/checkout', order)
                                                .then((res) => {
                                                    alert('Thanh toán thành công!');
                                                    setCart({});
                                                    localStorage.removeItem('cart');
                                                    navigate('/');
                                                })
                                                .catch((err) => console.log(err));
                                        });
                                    }}
                                />
                            ) : null}
                            {show2 ? (
                                <button className={cx('pay-btn-buy')} onClick={handleCheckoutCOD}>
                                    Đặt hàng
                                </button>
                            ) : null}
                        </Row>
                    </Col>
                </Row>
            </Container>
        </PayPalScriptProvider>
    );
}

export default Pay;
