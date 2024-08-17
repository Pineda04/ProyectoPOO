import { FaSearch } from "react-icons/fa";

export const SearchTravelPackages = () => {
  return (
    <div className="flex items-center w-full md:w-auto mb-4 md:mb-0">
      <input
        type="text"
        placeholder="Buscar paquetes de viaje..."
        className="px-4 py-2 w-full md:w-64 rounded-l-lg border border-gray-700 bg-gray-800 text-gray-200 placeholder-gray-400 focus:outline-none focus:bg-gray-700"
      />
      <button className="bg-yellow-500 text-gray-900 rounded-r-lg px-4 flex items-center justify-center border border-gray-700 hover:bg-yellow-400 transition w-12 h-11 flex-shrink-0">
        <FaSearch className="text-gray-900" />
      </button>
    </div>
  );
};
