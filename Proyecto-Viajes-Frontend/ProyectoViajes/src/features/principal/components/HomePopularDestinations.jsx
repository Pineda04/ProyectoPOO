import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getDestinationsList } from "../../../shared/actions/destinations/destinations";

export const HomePopularDestinations = () => {
  const [destinations, setDestinations] = useState([]);
  const [filteredDestinations, setFilteredDestinations] = useState([]);

  useEffect(() => {
    const getDestinations = async () => {
        const response = await getDestinationsList();
        setDestinations(response.data.items);
        setFilteredDestinations(response.data.items);
      }

    getDestinations();
  }, []);

  return (
    <section className="py-12 md:py-20 bg-gray-800">
      <div className="container mx-auto px-4 md:px-6">
        <h3 className="text-3xl md:text-5xl font-bold text-center text-white mb-8 md:mb-12">
          Destinos Populares
        </h3>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {filteredDestinations.length ? (
            filteredDestinations.map((destination) => (
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
                  <Link
                    to={`/destinations/destination/${destination.id}`}
                    className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
                  >
                    Ver más
                  </Link>
                </div>
              </div>
            ))
          ) : (
            <p className="text-center text-white text-2xl md:text-3xl font-semibold">
              No hay destinos disponibles :(
            </p>
          )}
        </div>
      </div>
    </section>
  );
};
