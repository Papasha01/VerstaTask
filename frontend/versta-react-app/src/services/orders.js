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