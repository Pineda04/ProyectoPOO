export const DestinationDetailsSkeleton = () => {
  return (
    <div className="bg-gray-800 rounded-lg overflow-hidden shadow-xl mb-8 animate-pulse">
      <div className="w-full h-64 bg-gray-600"></div>
      <div className="p-4 md:p-6">
        <div className="h-8 bg-gray-500 rounded mb-4"></div>
        <div className="h-4 bg-gray-500 rounded mb-4"></div>
        <div className="h-4 bg-gray-500 rounded mb-4"></div>
      </div>
    </div>
  );
};
