import axios from "axios";

export const fetchOrders = async () => {
  try {
    var response = await axios.get("https://localhost:7127/Order");
    return response.data;
  } catch (ex) {
    console.error(ex);
  }
};

export const createOrder = async (order) => {
  try {
    var response = await axios.post("https://localhost:7127/Order", order);
    return response.status;
  } catch (ex) {
    console.error(ex);
  }
};
export const fetchOrder = async (id) => {
  try {
    const response = await axios.get(`https://localhost:7127/Order/${id}`);
    return response.data;
  } catch (ex) {
    console.error('Ошибка при получении заказа:', ex);
    throw ex; 
  }
};