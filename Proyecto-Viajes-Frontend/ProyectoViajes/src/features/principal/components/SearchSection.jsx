import { FaSearch } from 'react-icons/fa';

export const SearchSection = () => {
  return (
    <section className="py-12 bg-gray-800">
      <div className="container mx-auto px-4">
        <div className="flex justify-center mb-8">
          <input
            type="text"
            placeholder="Buscar destinos..."
            className="px-4 py-2 w-full md:w-1/2 rounded-l-lg border border-gray-700 bg-gray-800 text-gray-200 placeholder-gray-400"
          />
          <button className="bg-yellow-500 text-gray-900 rounded-r-lg px-4 flex items-center justify-center border border-gray-700 hover:bg-yellow-400 transition">
            <FaSearch className="text-gray-900" />
          </button>
        </div>
      </div>
    </section>
  );
};
