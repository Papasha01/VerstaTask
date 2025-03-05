import axios from "axios";

export const fetchOrders = async () => {
  try {
    var response = await axios.get("http://localhost:5056/Order");
    return response.data;
  } catch (ex) {
    console.error(ex);
  }
};

export const createOrder = async (order) => {
  try {
    var response = await axios.post("http://localhost:5056/Order", order);
    alert("Заказ успешно добавлен!")
    return response.status;
  } catch (ex) {
    console.error(ex);
  }
};