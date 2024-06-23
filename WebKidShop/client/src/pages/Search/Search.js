import Row from 'react-bootstrap/Row';
import axios from 'axios';
import ReactPaginate from 'react-paginate';
import Col from 'react-bootstrap/esm/Col';
import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import _ from 'lodash';

import NormalProduct from '../Home/Product/NormalProduct/NormalProduct';

import classNames from 'classnames/bind';
import styles from './Search.module.scss';

const cx = classNames.bind(styles);

function Search() {
    const location = useLocation();
    // eslint-disable-next-line
    const [productList, setProductList] = useState([]);
    const [products, setProducts] = useState([]);
    const [currentProducts, setCurrentProducts] = useState([]);
    const [pageCount, setPageCount] = useState(0);
    const [searchValue, setSearchKey] = useState('');
    const [promotion, setPromotion] = useState([]);

    useEffect(() => {
        const getProducts = async () => {
            try {
                const queryString = window.location.search;
                const urlParams = new URLSearchParams(queryString);
                const search = urlParams.get('search');
                setSearchKey(search);
                // //get data from product
                const res = await axios.get(`http://localhost:8080/api/product/search`, {
                    params: { search: search },
                });
                let arrObj = res.data;
                var newArr = [];
                arrObj = _.sortBy(arrObj, ['name']);
                for (var i = 0; i < arrObj.length; i++) {
                    if (arrObj[i]?.name !== arrObj[i + 1]?.name) {
                        newArr.push(arrObj[i]);
                    }
                }
                setProductList(newArr);
                setProducts(newArr);
                setCurrentProducts(newArr.slice(0, 12));
                setPageCount(Math.ceil(newArr.length / 12));
            } catch (e) {
                console.log(e);
            }
        };
        getProducts();
    }, [location]);

    useEffect(() => {
        axios
            .get('http://localhost:8080/api/promotion')
            .then((res) => {
                setPromotion(res.data);
            })
            .catch((err) => console.log(err));
    }, []);

    const handlePageClick = (e) => {
        const newOffset = (e.selected * 12) % products.length;
        const endOffset = newOffset + 12;
        setCurrentProducts(products.slice(newOffset, endOffset));
        setPageCount(Math.ceil(products.length / 12));
    };

    const setDiscount = (promotionID) => {
        const data = promotion.filter((promo) => {
            return promo._id === promotionID;
        });
        return data[0]?.discount;
    };

    return (
        <div>
            <Row>
                <h1 className={cx('search-lable')}>Kết quả tìm kiếm với từ khóa: {searchValue}</h1>
            </Row>
            <Row>
                {currentProducts.map((product) => {
                    return (
                        <Col xl={3} md={6}>
                            <NormalProduct
                                key={product._id}
                                to={`product/${product.name}`}
                                src={product.productPic}
                                oldPrice={product.price}
                                newPrice={
                                    product.promotion && (product.price * (100 - setDiscount(product.promotion))) / 100
                                }
                                discount={setDiscount(product.promotion)}
                                title={product.name}
                            />
                        </Col>
                    );
                })}
            </Row>
            <ReactPaginate
                breakLabel="..."
                nextLabel=">"
                onPageChange={handlePageClick}
                pageRangeDisplayed={3}
                pageCount={pageCount}
                previousLabel="<"
                renderOnZeroPageCount={null}
                containerClassName={cx('pagination')}
                pageLinkClassName={cx('page-num')}
                previousLinkClassName={cx('page-num')}
                nextLinkClassName={cx('page-num')}
                activeLinkClassName={cx('active')}
            />
        </div>
    );
}

export default Search;
