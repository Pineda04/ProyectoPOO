import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { FaSearch } from "react-icons/fa";
import { getTravelPackagesList } from "../../../shared/actions/travelPakages/travelPackages";
import { TravelPackagesFilter } from "./TravelPackagesFilter";

export const TravelPackagesList = () => {
  const [travelPackages, setTravelPackages] = useState([]);
  const [filteredPackages, setFilteredPackages] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedFilter, setSelectedFilter] = useState({});

  useEffect(() => {
    const getTravelPackages = async () => {
      const response = await getTravelPackagesList();
      setTravelPackages(response.data.items);
      setFilteredPackages(response.data.items);
    };

    getTravelPackages();
  }, []);

  const handleSearch = () => {
    const filtered = travelPackages.filter((pkg) =>
      pkg.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredPackages(filtered);
  };

  const handleKeyDown = (e) => {
    if (e.key === "Enter") {
      handleSearch();
    }
  };

  const handleFilterChange = ({ type, value }) => {
    setSelectedFilter((prev) => ({ ...prev, [type]: value }));
  };

  useEffect(() => {
    let updatedPackages = [...travelPackages];

    if (selectedFilter.price) {
      // Rangos de precio
      const priceRanges = {
        low: [0, 100],
        medium: [101, 500],
        high: [501, Infinity]
      };
      const [minPrice, maxPrice] = priceRanges[selectedFilter.price];
      updatedPackages = updatedPackages.filter(pkg =>
        pkg.price >= minPrice && pkg.price <= maxPrice
      );
    }

    if (selectedFilter.duration) {
      // Rangos de duración
      const durationRanges = {
        short: [1, 10],
        medium: [11, 31],
        long: [32, Infinity]
      };
      const [minDuration, maxDuration] = durationRanges[selectedFilter.duration];
      updatedPackages = updatedPackages.filter(pkg =>
        pkg.duration >= minDuration && pkg.duration <= maxDuration
      );
    }

    setFilteredPackages(updatedPackages);
  }, [selectedFilter, travelPackages]);

  return (
    <section className="py-12">
      <div className="container mx-auto px-4">
        <h2 className="text-3xl md:text-4xl font-bold text-center text-white mb-8">
          Paquetes de viaje
        </h2>
        
        <div className="flex flex-col md:flex-row items-center justify-between mb-8 space-y-4 md:space-y-0 md:space-x-4">
          {/* Barra busqueda */}
          <div className="flex items-center w-full md:w-auto">
            <input
              type="text"
              placeholder="Buscar paquetes de viaje..."
              className="px-4 py-2 w-full md:w-64 rounded-l-lg border border-gray-700 bg-gray-800 text-gray-200 placeholder-gray-400 focus:outline-none focus:bg-gray-700"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              onKeyDown={handleKeyDown}
            />
            <button
              className="bg-yellow-500 text-gray-900 rounded-r-lg px-4 flex items-center justify-center border border-gray-700 hover:bg-yellow-400 transition w-12 h-11 flex-shrink-0"
              onClick={handleSearch}
            >
              <FaSearch className="text-gray-900" />
            </button>
          </div>
          
          {/* filtrar */}
          <TravelPackagesFilter onFilterChange={handleFilterChange} />
        </div>
        
        {/* Lista de paquetes de viaje */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {filteredPackages.length ? (
            filteredPackages.map((pkg) => (
              <div
                key={pkg.id}
                className="bg-gray-700 rounded-lg overflow-hidden shadow-xl transform hover:scale-105 transition"
              >
                <img
                  src={pkg.imageUrl}
                  alt={pkg.name}
                  className="w-full h-48 sm:h-64 object-cover"
                />
                <div className="p-4 md:p-6">
                  <h4 className="text-xl md:text-2xl font-semibold text-yellow-500">
                    {pkg.name}
                  </h4>
                  <p className="mt-2 md:mt-3 text-gray-300">
                    {pkg.description}
                  </p>
                  <Link
                    to={`/travelPackages/travelPackage/${pkg.id}`}
                    className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
                  >
                    Ver más
                  </Link>
                </div>
              </div>
            ))
          ) : (
            <p className="text-white text-2xl md:text-3xl font-semibold">
              No se encontró el paquete :(
            </p>
          )}
        </div>
      </div>
    </section>
  );
};
