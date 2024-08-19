import { useEffect, useState } from "react";
import { getDestinationsList } from "../../../shared/actions/destinations/destinations";
import { DestinationsListSkeleton } from "./DestinationsListSkeleton";

export const HomePopularDestinations = () => {
  const [destinations, setDestinations] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getDestinations = async () => {
      setIsLoading(true);
      try {
        const response = await getDestinationsList();
        setDestinations(response.data.items);
      } catch (error) {
        console.error("Error:", error);
      } finally {
        setIsLoading(false);
      }
    };

    getDestinations();
  }, []);

  const skeletonCount = Math.min(3, destinations.length);

  return (
    <section className="py-12 md:py-20 bg-gray-800">
      <div className="container mx-auto px-4 md:px-6">
        <h3 className="text-3xl md:text-5xl font-bold text-center text-white mb-8 md:mb-12">
          Destinos Populares
        </h3>
        {isLoading ? (
          <DestinationsListSkeleton count={skeletonCount} />
        ) : (
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
            {destinations.slice(0, 3).map((destination) => (
              <div
                key={destination.id}
                className="bg-gray-700 rounded-lg overflow-hidden shadow-xl transform hover:scale-105 transition"
              >
                <img
                  src={destination.imageUrl}
                  alt={destination.name}
                  className="w-full h-48 sm:h-64 object-cover"
                />
                <div className="p-4 md:p-6">
                  <h4 className="text-xl md:text-2xl font-semibold text-yellow-500">
                    {destination.name}
                  </h4>
                  <p className="mt-2 md:mt-3 text-gray-300">
                    {destination.description}
                  </p>
                  <a
                    href="#"
                    className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
                  >
                    Ver más
                  </a>
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </section>
  );
};
