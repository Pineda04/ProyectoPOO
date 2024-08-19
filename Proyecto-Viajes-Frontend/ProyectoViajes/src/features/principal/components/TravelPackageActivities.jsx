import {useActivities} from '../hooks/useActivities';

export const TravelPackageActivities = ({ travelPackageId }) => {
  const { data, loading } = useActivities(travelPackageId);

  if (loading) return <p>Cargando...</p>;

  return (
    <>
      <section className="mb-8 bg-gray-800 rounded-lg overflow-hidden shadow-xl">
        <div className="p-4 md:p-6">
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
                {data.length > 0 ? (
                  data.map(activity => (
                    <tr key={activity.id} className="border-b border-gray-700">
                      <td className="py-3 px-4 text-gray-300">{activity.name}</td>
                      <td className="py-3 px-4 text-gray-400">{activity.description}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan="2" className="py-3 px-4 text-gray-400 text-center">No hay actividades disponibles.</td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>
      </section>
    </>
  );
};
