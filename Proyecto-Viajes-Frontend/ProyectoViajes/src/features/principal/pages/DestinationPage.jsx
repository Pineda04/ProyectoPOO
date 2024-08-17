import { DestinationDetails, PointsOfInterest } from "../components";

export const DestinationPage = () => {
  return (
    <>
      <div className="container mx-auto p-6">
        <DestinationDetails />
        <PointsOfInterest />
      </div>
    </>
  );
};
