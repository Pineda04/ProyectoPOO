import { useState } from "react";

export const TravelPackagesFilter = ({ onFilterChange }) => {
  const [selectedPrice, setSelectedPrice] = useState("");
  const [selectedDuration, setSelectedDuration] = useState("");

  const handlePriceChange = (e) => {
    setSelectedPrice(e.target.value);
    onFilterChange({
      type: "price",
      value: e.target.value
    });
  };

  const handleDurationChange = (e) => {
    setSelectedDuration(e.target.value);
    onFilterChange({
      type: "duration",
      value: e.target.value
    });
  };

  return (
    <div className="flex items-center space-x-2 md:space-x-4">
      <span className="text-gray-300">Filtrar por:</span>
      <select
        value={selectedPrice}
        onChange={handlePriceChange}
        className="p-2 border border-gray-300 rounded-lg bg-gray-800 text-gray-200"
      >
        <option value="">Seleccionar Precio</option>
        <option value="low">Bajo</option>
        <option value="medium">Medio</option>
        <option value="high">Alto</option>
      </select>
      <select
        value={selectedDuration}
        onChange={handleDurationChange}
        className="p-2 border border-gray-300 rounded-lg bg-gray-800 text-gray-200"
      >
        <option value="">Seleccionar Duración</option>
        <option value="short">Corta</option>
        <option value="medium">Media</option>
        <option value="long">Larga</option>
      </select>
    </div>
  );
};
