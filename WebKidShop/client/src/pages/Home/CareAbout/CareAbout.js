import Container from 'react-bootstrap/esm/Container';
import Row from 'react-bootstrap/esm/Row';
import Col from 'react-bootstrap/esm/Col';
import { useEffect, useState } from 'react';
import axios from 'axios';

import NormalProduct from '../Product/NormalProduct/NormalProduct';
import classNames from 'classnames/bind';
import styles from './CareAbout.module.scss';

const cx = classNames.bind(styles);

function CareAbout() {
    const [products, setProducts] = useState([]);
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

    useEffect(() => {
        const getProducts = async () => {
            try {
                const res = await axios.get(`http://localhost:8080/api/product`);
                setProducts(res.data.slice(0, 4));
            } catch (e) {
                console.log(e);
            }
        };
        getProducts();
    }, []);

    return (
        <Container>
            <h2 className={cx('careabout-lable')}>Có thể bạn quan tâm</h2>
            <h4 className={cx('careabout-desc')}>
                Bạn có thể tìm thấy những phẩm tốt và chi phí được giảm tới 70% với những mẫu mã đa dạng và phù hợp với
                hầu bao cả các bà mẹ. Chúng tôi cam kết luôn mang đến cho các mẹ và bé những sản phẩm tốt nhất, chất
                lượng nhất.
            </h4>

            <Row className={cx('careabout-row')}>
                {products.map((product) => {
                    return (
                        <Col>
                            <NormalProduct
                                src={product.productPic}
                                oldPrice={product.price}
                                newPrice={
                                    product.promotion && (product.price * (100 - setDiscount(product.promotion))) / 100
                                }
                                discount={setDiscount(product.promotion)}
                                title={product.name}
                                to={`category/product/${product.name}`}
                            />
                        </Col>
                    );
                })}
            </Row>
        </Container>
    );
}

export default CareAbout;
