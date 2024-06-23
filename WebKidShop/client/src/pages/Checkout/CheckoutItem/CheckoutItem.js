import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleCheck, faCircleInfo, faCircleXmark } from '@fortawesome/free-solid-svg-icons';

import classNames from 'classnames/bind';
import styles from './CheckoutItem.module.scss';
import axios from 'axios';
import { useState } from 'react';

const cx = classNames.bind(styles);

function CheckoutItem(props) {
    const { idOrder, dateOrder, statusOrder, amount } = props;

    // eslint-disable-next-line
    const [date, setDate] = useState(new Date(dateOrder));

    const handleDelivered = (e) => {
        e.preventDefault();

        axios
            .patch(`http://localhost:8080/api/checkout/${idOrder}/status`, {
                status: 'Delivered',
            })
            .then((res) => {
                alert('Đơn hàng được nhận thành công!');
                window.location.reload();
            })
            .catch((err) => {
                console.log(err);
            });
    };

    const handleReject = (e) => {
        e.preventDefault();

        axios
            .patch(`http://localhost:8080/api/checkout/${idOrder}/status`, {
                status: 'Reject',
            })
            .then((res) => {
                alert('Đơn hàng bị huỷ thành công!');
                window.location.reload();
            })
            .catch((err) => {
                console.log(err);
            });
    };

    return (
        <tr>
            <td>{idOrder}</td>
            <td>{date.getDate() + '-' + (date.getMonth() + 1) + '-' + date.getFullYear()}</td>
            <td>{statusOrder}</td>
            <td>{amount}</td>

            <td>
                <div className={cx('orders-body-actions')}>
                    <button className={cx('orders-body-action')}>
                        <FontAwesomeIcon icon={faCircleInfo} />
                    </button>
                    {statusOrder === 'Pending' && (
                        <div>
                            <button className={cx('orders-body-action')}>
                                <FontAwesomeIcon
                                    icon={faCircleXmark}
                                    className={cx('orders-action-xmark')}
                                    onClick={handleReject}
                                />
                            </button>
                        </div>
                    )}
                    {statusOrder === 'Confirmed' && (
                        <div>
                            <button className={cx('orders-body-action')}>
                                <FontAwesomeIcon
                                    icon={faCircleCheck}
                                    className={cx('orders-action-check')}
                                    onClick={handleDelivered}
                                />
                            </button>
                        </div>
                    )}
                </div>
            </td>
        </tr>
    );
}

export default CheckoutItem;
