import { travelApi } from "../../../config/api";

export const registerUser = async (userData) => {
  try {
    const { data } = await travelApi.post('/users', userData);
    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};
