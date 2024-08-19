import { travelApi } from "../../../config/api";

export const getTravelPackagesList = async (searchTerm = "", page = 1) => {
  try {
    const {data} = await travelApi.get(
      `/travel_packages?searchTerm=${searchTerm}&page=${page}`
    );
    
    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};

export const getTravelPackageDetails = async (id) => {
  try {
    const { data } = await travelApi.get(`/travel_packages/${id}`);
    
    return data;
  } catch (error) {
    console.error('Error fetching destination details:', error);
    return error.response;
  }
};
