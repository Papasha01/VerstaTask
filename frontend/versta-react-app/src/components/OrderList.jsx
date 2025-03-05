import { fetchOrders } from "@/services/orders";
import { Table, Button, DataList } from "@chakra-ui/react";
import moment from "moment";
import { useEffect, useRef, useState } from "react";
import OrderAdd from "./OrderAdd";
import {
  DialogActionTrigger,
  DialogBody,
  DialogCloseTrigger,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogRoot,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import "react-datepicker/dist/react-datepicker.css";
import "./ui/date-picker.css";

function OrderList() {

  const [order, setOrder] = useState({
    senderCity: "",
    senderAddress: "",
    recipientCity: "",
    recipientAddress: "",
    cargoWeight: 0.1,
    pickupDate: new Date(),
  });
  const orderStats = [
    { label: "Город отправителя", value: order.senderCity },
    { label: "Адрес отправителя", value: order.senderAddress },
    { label: "Город получателя", value: order.recipientCity },
    { label: "Адрес получателя", value: order.recipientAddress },
    { label: "Вес груза", value: `${order.cargoWeight} кг` },
    { label: "Дата забора", value: order.pickupDate },
  ];
  const handleRowClick = (order) => {
    setOrder(order);
  };
  const [orders, setOrders] = useState([]);
  const fetchData = async () => {
    let orders = await fetchOrders();
    setOrders(orders);
  };
  
  const didMountRef = useRef(false);
  useEffect(() => {
    if (didMountRef.current) return;
    didMountRef.current = true;

    fetchData();
  }, []);

  return (
    <>
      <OrderAdd onButtonClick={fetchData}/>

      <DialogRoot>
        <DialogTrigger asChild>
          <Table.Root size="sm">
            <Table.Header>
              <Table.Row>
                <Table.ColumnHeader>ID</Table.ColumnHeader>
                <Table.ColumnHeader>Город отправителя</Table.ColumnHeader>
                <Table.ColumnHeader>Адрес отправителя</Table.ColumnHeader>
                <Table.ColumnHeader>Город получателя</Table.ColumnHeader>
                <Table.ColumnHeader>Адрес получателя</Table.ColumnHeader>
                <Table.ColumnHeader>Вес груза</Table.ColumnHeader>
                <Table.ColumnHeader>Дата забора</Table.ColumnHeader>
                <Table.ColumnHeader>Создано</Table.ColumnHeader>
              </Table.Row>
            </Table.Header>

            <Table.Body>
              {orders.map((item) => (
                <Table.Row
                  key={item.id}
                  onClick={() => handleRowClick(item)}
                  cursor="pointer"
                  _hover={{ bg: "gray.100" }}
                >
                  <Table.Cell>{item.id}</Table.Cell>
                  <Table.Cell>{item.senderCity}</Table.Cell>
                  <Table.Cell>{item.senderAddress}</Table.Cell>
                  <Table.Cell>{item.recipientCity}</Table.Cell>
                  <Table.Cell>{item.recipientAddress}</Table.Cell>
                  <Table.Cell>{item.cargoWeight}</Table.Cell>
                  <Table.Cell>
                    {moment(item.pickupDate).format("DD.MM.YYYY")}
                  </Table.Cell>
                  <Table.Cell>
                    {moment(item.createdAt).format("DD.MM.YYYY h:mm:ss")}
                  </Table.Cell>
                </Table.Row>
              ))}
            </Table.Body>
          </Table.Root>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Dialog Title</DialogTitle>
          </DialogHeader>
          <DialogBody>
            <div>
              <DataList.Root orientation="vertical">
                {" "}
                {/* Изменил ориентацию на вертикальную для лучшего отображения */}
                {orderStats.map((item) => (
                  <DataList.Item key={item.label}>
                    <DataList.ItemLabel>{item.label}</DataList.ItemLabel>
                    <DataList.ItemValue>{item.value}</DataList.ItemValue>
                  </DataList.Item>
                ))}
              </DataList.Root>
            </div>
          </DialogBody>
          <DialogFooter>

          </DialogFooter>
          <DialogCloseTrigger />
        </DialogContent>
      </DialogRoot>
    </>
  );
}

export default OrderList;
