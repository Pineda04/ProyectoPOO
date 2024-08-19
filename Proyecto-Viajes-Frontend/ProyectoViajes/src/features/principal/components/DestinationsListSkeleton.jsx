export const DestinationsListSkeleton = ({ count }) => {
  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
      {Array.from({ length: count }).map((_, index) => (
        <div
          key={index}
          className="bg-gray-700 rounded-lg overflow-hidden shadow-xl animate-pulse"
        >
          <div className="w-full h-48 sm:h-64 bg-gray-600"></div>
          <div className="p-4 md:p-6">
            <div className="h-6 bg-gray-500 rounded mb-4"></div>
            <div className="h-4 bg-gray-500 rounded mb-4"></div>
            <div className="h-4 bg-gray-500 rounded mb-4"></div>
          </div>
        </div>
      ))}
    </div>
  );
};
