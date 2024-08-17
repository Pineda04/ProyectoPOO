export const TravelPackagesFilter = () => {
  return (
    <div className="flex items-center space-x-2 md:space-x-4">
      <span className="text-gray-300">Filtrar por:</span>
      <select className="p-2 border border-gray-300 rounded-lg bg-gray-800 text-gray-200">
        <option value="">Seleccionar Filtro</option>
        <option value="destination">Destino</option>
        <option value="agency">Agencia</option>
        <option value="rating">Valoración</option>
        <option value="price">Precio</option>
        <option value="duration">Duración</option>
      </select>
    </div>
  )
}
