import { Navigate, Route, Routes } from "react-router-dom";
import { PrincipalFooter, PrincipalHeader } from "../components";
import { PrincipalPage } from "../pages";

export const PrincipalRouter = () => {
  return (
    <div className="bg-gray-900 text-gray-200 min-h-screen">
      <PrincipalHeader />
      <Routes>
        <Route path='/home' element={<PrincipalPage/>}/>
        <Route path='/*' element={<Navigate to={"/home"}/>}/>
      </Routes>
      <PrincipalFooter/>
    </div>
  );
};
