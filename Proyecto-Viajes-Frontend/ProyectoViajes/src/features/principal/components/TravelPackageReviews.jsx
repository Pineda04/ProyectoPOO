import { FaStar } from "react-icons/fa";

export const TravelPackageReviews = () => {
  return (
    <>
      <h3 className="text-2xl font-semibold text-yellow-500 mb-6">Valoraciones</h3>
      <div className="bg-gray-700 rounded-lg p-6 mb-6">
        <div className="mb-6 p-4 border border-gray-600 rounded-lg shadow-md">
          <div className="flex items-center mb-4">
            {[...Array(5)].map((_, i) => (
              <FaStar
                key={i}
                className={`text-${i < 5 ? 'yellow' : 'gray'}-400`}
              />
            ))}
            <span className="ml-2 text-gray-300 font-semibold">5 / 5.0</span>
          </div>
          <div className="text-gray-300">
            <p><strong>Usuario:</strong> Una experiencia increíble!</p>
          </div>
        </div>

        <div className="mb-6 p-4 border border-gray-600 rounded-lg shadow-md">
          <div className="flex items-center mb-4">
            {[...Array(5)].map((_, i) => (
              <FaStar
                key={i}
                className={`text-${i < 4 ? 'yellow' : 'gray'}-400`}
              />
            ))}
            <span className="ml-2 text-gray-300 font-semibold">4 / 5.0</span>
          </div>
          <div className="text-gray-300">
            <p><strong>Usuario:</strong> Buen paquete, pero puede mejorar.</p>
          </div>
        </div>

        <div className="mb-6 p-4 border border-gray-600 rounded-lg shadow-md">
          <div className="flex items-center mb-4">
            {[...Array(5)].map((_, i) => (
              <FaStar
                key={i}
                className={`text-${i < 3 ? 'yellow' : 'gray'}-400`}
              />
            ))}
            <span className="ml-2 text-gray-300 font-semibold">3 / 5.0</span>
          </div>
          <div className="text-gray-300">
            <p><strong>Usuario:</strong> Experiencia aceptable, pero hay áreas de mejora.</p>
          </div>
        </div>
      </div>
    </>
  );
};
