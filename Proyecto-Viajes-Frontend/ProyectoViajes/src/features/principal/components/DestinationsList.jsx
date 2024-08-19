import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { useDestinations } from "../hooks";
import { FaSearch } from "react-icons/fa";
import { DestinationsListSkeleton } from "./DestinationsListSkeleton";

export const DestinationsList = () => {
  const { destinations, loadDestinations, isLoading } = useDestinations();
  const [currentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [inputValue, setInputValue] = useState("");

  useEffect(() => {
    loadDestinations(searchTerm, currentPage);
  }, [searchTerm, currentPage]);

  const handleKeyPress = (event) => {
    if (event.key === "Enter") {
      setSearchTerm(inputValue);
    }
  };

  const handleButtonClick = () => {
    setSearchTerm(inputValue);
  };

  const skeletonCount = destinations?.data?.items?.length || 3;

  return (
    <div>
      <section className="py-12 bg-gray-800">
        <div className="container mx-auto px-4">
          <div className="flex justify-center mb-8">
            <input
              type="text"
              placeholder="Buscar destinos..."
              value={inputValue}
              onChange={(e) => setInputValue(e.target.value)}
              onKeyDown={handleKeyPress}
              className="px-4 py-2 w-full md:w-1/2 rounded-l-lg border border-gray-700 bg-gray-800 text-gray-200 placeholder-gray-400"
            />
            <button
              onClick={handleButtonClick}
              className="bg-yellow-500 text-gray-900 rounded-r-lg px-4 flex items-center justify-center border border-gray-700 hover:bg-yellow-400 transition"
            >
              <FaSearch className="text-gray-900" />
            </button>
          </div>
        </div>
      </section>

      <section className="py-12">
        <div className="container mx-auto px-4">
          <h2 className="text-3xl md:text-4xl font-bold text-center text-white mb-8">
            Destinos
          </h2>
          {isLoading ? (
            <DestinationsListSkeleton count={skeletonCount} />
          ) : (
            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
              {destinations?.data?.items?.length ? (
                destinations.data.items.map((destination) => (
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
          )}
        </div>
      </section>
    </div>
  );
};