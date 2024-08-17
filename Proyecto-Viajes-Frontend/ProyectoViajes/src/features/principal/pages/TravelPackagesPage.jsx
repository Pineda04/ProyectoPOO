import { SearchTravelPackages, TravelPackagesFilter, TravelPackagesList } from "../components";

export const TravelPackagesPage = () => {
  return (
    <>
      <div className="container mx-auto px-4 md:px-6 mt-8 md:mt-12">
        <div className="flex flex-col md:flex-row justify-between items-center">
          <SearchTravelPackages />
          <TravelPackagesFilter />
        </div>
      </div>
      <TravelPackagesList/>
    </>
  );
};
