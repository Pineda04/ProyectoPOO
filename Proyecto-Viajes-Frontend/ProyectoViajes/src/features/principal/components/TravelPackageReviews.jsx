import { FaStar } from "react-icons/fa";
import {useAssessments} from '../hooks/useAssessments';

export const TravelPackageReviews = ({ travelPackageId }) => {
  const { data, loading } = useAssessments(travelPackageId);

  if (loading) return <p>Cargando...</p>;

  const filteredReviews = data.filter(review => review.packageId === travelPackageId);

  return (
    <section className="mb-8 bg-gray-800 rounded-lg overflow-hidden shadow-xl">
      <div className="p-4 md:p-6">
        <h3 className="text-2xl font-semibold text-yellow-500 mb-6">Valoraciones</h3>
        <div className="overflow-x-auto">
          {filteredReviews.length > 0 ? (
            filteredReviews.map((review) => (
              <div key={review.id} className="mb-6 p-4 border border-gray-600 rounded-lg shadow-md">
                <div className="flex items-center mb-4">
                  {[...Array(5)].map((_, i) => (
                    <FaStar
                      key={i}
                      className={`text-${i < review.rating ? 'yellow' : 'gray'}-400`}
                    />
                  ))}
                  <span className="ml-2 text-gray-300 font-semibold">{review.rating} / 5.0</span>
                </div>
                <div className="text-gray-300">
                  <p><strong>Comentario:</strong> {review.comment}</p>
                </div>
              </div>
            ))
          ) : (
            <p className="text-gray-400 text-center">No hay valoraciones disponibles para este paquete de viaje.</p>
          )}
        </div>
      </div>
    </section>
  );
};
