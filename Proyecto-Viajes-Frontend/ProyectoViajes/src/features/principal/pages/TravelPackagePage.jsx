import { ReviewForm, TravelPackageReviews } from "../components";
import { TravelPackageActivities } from "../components/TravelPackageActivities";
import { TravelPackageDetails } from "../components/TravelPackageDetails";

export const TravelPackagePage = () => {
  return (
    <>
      <TravelPackageDetails />
      <div className="container mx-auto px-4 md:px-6 mb-12">
        <TravelPackageActivities />
        <TravelPackageReviews />
        <ReviewForm />
      </div>
    </>
  );
};
