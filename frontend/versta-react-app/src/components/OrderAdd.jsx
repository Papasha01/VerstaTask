import { createOrder } from "@/services/orders";
import { Button } from "@chakra-ui/react";
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
import { Field } from "@/components/ui/field";
import { Input } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import {
  NumberInputField,
  NumberInputRoot,
} from "@/components/ui/number-input";
import DatePicker from "react-datepicker";

function OrderAdd({ onButtonClick }) {
  const [order, setOrder] = useState({
    senderCity: "",
    senderAddress: "",
    recipientCity: "",
    recipientAddress: "",
    cargoWeight: 0.1,
    pickupDate: new Date(),
  });
  const formatDate = (date) => {
    const pad = (num, size) => num.toString().padStart(size, "0");
    const year = date.getFullYear();
    const month = pad(date.getMonth() + 1, 2); // Месяцы начинаются с 0
    const day = pad(date.getDate(), 2);
    return `${year}-${month}-${day}`;
  };

  const handleChange = (e) => {
    setOrder({ ...order, [e.target.name]: e.target.value });
  };
  const handleNumberChange = (value) => {
    console.log(parseFloat(value.value).toFixed(1))
    setOrder({ ...order, cargoWeight: parseFloat(value.value).toFixed(1) });
  };
  const handleDateChange = (date) => {
    setOrder({ ...order, pickupDate: date });
  };
  const [isDisabled, setIsDisabled] = useState(true);
  const handleSave = () => {
    const formattedOrder = {
      ...order,
      pickupDate: formatDate(order.pickupDate),
    };
    createOrder(formattedOrder);
    setTimeout(() => {
      onButtonClick();
    }, 50);
    onButtonClick();
    setOrder({
      senderCity: "",
      senderAddress: "",
      recipientCity: "",
      recipientAddress: "",
      cargoWeight: 0.1,
      pickupDate: new Date(),
    });
  };
  useEffect(() => {
    const { senderCity, senderAddress, recipientCity, recipientAddress } =
      order;
    if (senderCity && senderAddress && recipientCity && recipientAddress) {
      setIsDisabled(false);
    } else {
      setIsDisabled(true);
    }
  }, [order]);

  return (
    <>
      <DialogRoot
        key={"center"}
        placement={"center"}
        motionPreset="slide-in-bottom"
      >
        <DialogTrigger asChild>
          <Button variant="outline">Добавить заказ</Button>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Новый заказ</DialogTitle>
          </DialogHeader>
          <DialogBody>
            <div>
              <Field label="Город отправителя" required>
                <Input
                  name="senderCity"
                  value={order.senderCity}
                  onChange={handleChange}
                  placeholder="Введите город"
                />
              </Field>
              <Field label="Адрес отправителя" required>
                <Input
                  name="senderAddress"
                  value={order.senderAddress}
                  onChange={handleChange}
                  placeholder="Введите адрес"
                />
              </Field>
              <Field label="Город получателя" required>
                <Input
                  name="recipientCity"
                  value={order.recipientCity}
                  onChange={handleChange}
                  placeholder="Введите город"
                />
              </Field>
              <Field label="Адрес получателя" required>
                <Input
                  name="recipientAddress"
                  value={order.recipientAddress}
                  onChange={handleChange}
                  placeholder="Введите адрес"
                />
              </Field>
              <Field label="Вес груза (кг)" required>
                <NumberInputRoot
                  defaultValue={0.1}
                  width="100%"
                  min={0.1}
                  max={9999}
                  step={0.1}
                  onValueChange={handleNumberChange}
                >
                  <NumberInputField />
                </NumberInputRoot>
              </Field>

              <Field label="Дата забора груза" required>
                <DatePicker
                  selected={order.pickupDate}
                  onChange={handleDateChange}
                  minDate={new Date()}
                />
              </Field>
            </div>
          </DialogBody>
          <DialogFooter>
            <DialogActionTrigger asChild>
              <Button variant="outline">Отмена</Button>
            </DialogActionTrigger>
            <Button disabled={isDisabled} onClick={handleSave}>
              Сохранить
            </Button>
          </DialogFooter>
          <DialogCloseTrigger />
        </DialogContent>
      </DialogRoot>
    </>
  );
}
export default OrderAdd;
