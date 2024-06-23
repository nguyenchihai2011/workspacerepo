import Container from 'react-bootstrap/esm/Container';
import Row from 'react-bootstrap/esm/Row';
import Col from 'react-bootstrap/esm/Col';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleRight } from '@fortawesome/free-solid-svg-icons';
import { useState, useEffect } from 'react';
import axios from 'axios';

import classNames from 'classnames/bind';
import styles from './Product.module.scss';

import Brand from './Brand/Brand';
import SellestProduct from '../../../layouts/components/SellestProduct/SellestProduct';
// import SellProduct from '../../../layouts/components/SellestProduct/SellProduct/SellProduct';
import NormalProduct from './NormalProduct/NormalProduct';

const cx = classNames.bind(styles);

function Product() {
    const [products, setProducts] = useState([]);
    const [products2, setProducts2] = useState([]);
    const [products4, setProducts4] = useState([]);

    useEffect(() => {
        axios
            .get('http://localhost:8080/api/product/')
            .then((res) => {
                setProducts(res.data);
                setProducts2(res.data.filter((pro, i) => i < 2));
                setProducts4(res.data.filter((pro, i) => i < 4));
            })
            .catch((err) => {
                console.log(err);
            });
    }, [products]);

    const [promotion, setPromotion] = useState([]);

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

    return (
        <div className={cx('product')}>
            <Container>
                <Row>
                    <Col xl={3} className={cx('product-aside')}>
                        <Row>
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo1.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo2.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo3.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo4.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo5.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo6.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo7.png?1564585558451" />
                            <Brand src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/logo8.png?1564585558451" />
                        </Row>
                        <SellestProduct products={products4} />

                        <div className={cx('contact')}>
                            <div className={cx('sub-contact')}>
                                <h5 className={cx('contact-title')}>HOTLINE</h5>
                                <h5 className={cx('contact-phone')}>0963.647.129</h5>
                            </div>
                        </div>
                    </Col>
                    <Col xl={9}>
                        <h3 className={cx('hot-product-lable')}>Sản phẩm nổi bật</h3>
                        <Row>
                            <Col xl={6} md={6}>
                                <Link to="" className={cx('hot-product')}>
                                    <img
                                        className={cx('product-img')}
                                        src="https://bizweb.dktcdn.net/thumb/grande/100/117/632/products/aovay1.jpg?v=1473603655807"
                                        alt=""
                                    />
                                    <div className={cx('product-sale')}>-9%</div>
                                    <div className={cx('product-info')}>
                                        <h5 className={cx('product-new-price')}>250.000đ</h5>
                                        <h5 className={cx('product-old-price')}>275.000đ</h5>
                                        <h5 className={cx('product-title')}>Váy liền thân KIDS - KF5</h5>
                                        <img
                                            src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/btn-buy.png?1564585558451"
                                            alt=""
                                        />
                                    </div>
                                </Link>
                            </Col>
                            <Col xl={6} md={6}>
                                <Row>
                                    {products2.map((product) => {
                                        return (
                                            <Col>
                                                <NormalProduct
                                                    src={product.productPic}
                                                    oldPrice={product.price}
                                                    newPrice={
                                                        product.promotion &&
                                                        (product.price * (100 - setDiscount(product.promotion))) / 100
                                                    }
                                                    discount={setDiscount(product.promotion)}
                                                    title={product.name}
                                                    to={`category/product/${product.name}`}
                                                />
                                            </Col>
                                        );
                                    })}
                                </Row>
                                <div className={cx('hot-product-see-all')}>
                                    <Link to="/category" className={cx('view-full-product')}>
                                        <div className={cx('full-product-border')}>
                                            Xem toàn bộ sản phẩm
                                            <FontAwesomeIcon
                                                className={cx('view-full-product-icon')}
                                                icon={faCircleRight}
                                            />
                                        </div>
                                    </Link>
                                </div>
                            </Col>
                        </Row>
                        <div className={cx('new-product')}>
                            <h3 className={cx('new-product-lable')}>Hàng mới về!</h3>
                            <div className={cx('new-product-type')}>
                                <Link to="" className={cx('product-type-btn')}>
                                    Bé trai
                                </Link>
                                <Link to="" className={cx('product-type-btn')}>
                                    Bé gái
                                </Link>
                                <Link to="" className={cx('product-type-btn')}>
                                    Phụ kiện
                                </Link>
                            </div>
                        </div>
                        <Row className={cx('new-product-list')}>
                            {products4.map((product) => {
                                return (
                                    <Col>
                                        <NormalProduct
                                            src={product.productPic}
                                            oldPrice={product.price}
                                            newPrice={
                                                product.promotion &&
                                                (product.price * (100 - setDiscount(product.promotion))) / 100
                                            }
                                            discount={setDiscount(product.promotion)}
                                            title={product.name}
                                            to={`category/product/${product.name}`}
                                        />
                                    </Col>
                                );
                            })}
                        </Row>
                        <img
                            className={cx('ads-img')}
                            src="https://bizweb.dktcdn.net/100/117/632/themes/157694/assets/banner1.gif?1564585558451"
                            alt=""
                        />
                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default Product;
