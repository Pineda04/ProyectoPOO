export const TravelPackageActivities = () => {
  return (
    <section className="mb-8">
      <h3 className="text-2xl font-semibold text-yellow-500 mb-6">Actividades Incluidas</h3>
      <div className="overflow-x-auto">
        <table className="min-w-full bg-gray-800 border border-gray-700 rounded-lg">
          <thead>
            <tr className="text-left text-gray-300">
              <th className="py-3 px-4 border-b border-gray-700">Actividad</th>
              <th className="py-3 px-4 border-b border-gray-700">Descripción</th>
            </tr>
          </thead>
          <tbody>
            <tr className="border-b border-gray-700">
              <td className="py-3 px-4 text-gray-300">Visita a la Torre Eiffel</td>
              <td className="py-3 px-4 text-gray-400">Disfruta de una vista panorámica de la ciudad desde el emblemático monumento.</td>
            </tr>
            <tr className="border-b border-gray-700">
              <td className="py-3 px-4 text-gray-300">Recorrido por el Louvre</td>
              <td className="py-3 px-4 text-gray-400">Explora una de las colecciones de arte más grandes del mundo.</td>
            </tr>
            <tr className="border-b border-gray-700">
              <td className="py-3 px-4 text-gray-300">Paseo en barco por el Sena</td>
              <td className="py-3 px-4 text-gray-400">Relájate con un paseo en barco por el río Sena y disfruta de las vistas de París.</td>
            </tr>
          </tbody>
        </table>
      </div>
    </section>
  );
};
