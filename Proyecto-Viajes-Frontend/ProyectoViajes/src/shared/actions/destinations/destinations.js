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

export const getDestinationDetails = async (id) => {
  try {
    const { data } = await travelApi.get(`/destinations/${id}`);
    
    return data;
  } catch (error) {
    console.error('Error fetching destination details:', error);
    return error.response;
  }
};

