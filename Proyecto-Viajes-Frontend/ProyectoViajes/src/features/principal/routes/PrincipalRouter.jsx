import { Navigate, Route, Routes } from "react-router-dom";
import { Footer, Header } from "../components";
import { HomePage, DestinationsPage, DestinationPage, TravelPackagesPage} from "../pages";

export const PrincipalRouter = () => {
  return (
    <div className="bg-gray-900 text-gray-200 min-h-screen">
      <Header />
      <Routes>
        <Route path='/home' element={<HomePage/>}/>
        <Route path='/destinations' element={<DestinationsPage/>}/>
        <Route path='/destinations/destination/:id' element={<DestinationPage/>}/>
        <Route path='/travelPackages' element={<TravelPackagesPage/>}/>
        <Route path='/*' element={<Navigate to={"/home"}/>}/>
      </Routes>
      <Footer/>
    </div>
  );
};
