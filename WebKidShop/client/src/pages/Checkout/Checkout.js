import className from 'classnames/bind';
import styles from './Checkout.module.scss';
import Row from 'react-bootstrap/esm/Row';
import { useState, useEffect } from 'react';
import axios from 'axios';
import Table from 'react-bootstrap/Table';
import CheckoutItem from './CheckoutItem/CheckoutItem';
import { useAuth } from '../../context/auth';

const cx = className.bind(styles);

function Checkout() {
    const [orders, setOrders] = useState([]);
    const [auth] = useAuth();

    useEffect(() => {
        axios.get(`http://localhost:8080/api/checkout/user/${auth.user?._id}`).then((res) => {
            setOrders(res.data.orders.reverse());
        });
    }, [auth]);

    return (
        <div>
            <Row>
                <h1 className={cx('checkout-lable')}>Đơn hàng</h1>
            </Row>
            <Row>
                <Table striped bordered hover className={cx('orders-table')}>
                    <thead className={cx('orders-header')}>
                        <tr>
                            <th>OrderID</th>
                            <th>Date</th>
                            <th>Status</th>
                            <th>Amount</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody className={cx('orders-body')}>
                        {orders.map((order) => {
                            return (
                                <CheckoutItem
                                    key={order._id}
                                    idOrder={order._id}
                                    dateOrder={order.orderDate}
                                    statusOrder={order.status}
                                    amount={order?.order.reduce((total, item) => {
                                        return total + item.price * item.quantity;
                                    }, 0)}
                                />
                            );
                        })}
                    </tbody>
                </Table>
            </Row>
        </div>
    );
}

export default Checkout;
