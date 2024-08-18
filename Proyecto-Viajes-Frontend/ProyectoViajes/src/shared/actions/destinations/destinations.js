import { travelApi } from "../../../config/api";

export const getDestinationsList = async (searchTerm = "", page = 1) => {
  try {
    const {data} = await travelApi.get(
      `/destinations?searchTerm=${searchTerm}&page=${page}`
    );
    
    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};
