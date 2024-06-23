import Row from 'react-bootstrap/esm/Row';
import classNames from 'classnames/bind';
import styles from './SellestProduct.module.scss';
import { useState, useEffect } from 'react';
import axios from 'axios';

import SellProduct from './SellProduct/SellProduct';

const cx = classNames.bind(styles);

function SellestProduct(props) {
    const { products } = props;
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
        <Row>
            <h5 className={cx('sellest-product-lable')}>Sản phẩm bán chạy</h5>
            {products?.map((product) => {
                return (
                    <SellProduct
                        key={product._id}
                        to={`category/product/${product.name}`}
                        src={product.productPic}
                        title={product.name}
                        oldPrice={product.price}
                        newPrice={product.promotion && (product.price * (100 - setDiscount(product.promotion))) / 100}
                    />
                );
            })}
        </Row>
    );
}

export default SellestProduct;
