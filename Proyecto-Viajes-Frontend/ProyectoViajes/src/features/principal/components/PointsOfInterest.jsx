import { useState } from 'react';
import usePointsOfInterest from '../hooks/usePointsOfInterest';

export const PointsOfInterest = ({ destinationId }) => {
  const { data, loading, error } = usePointsOfInterest(destinationId);
  const [isImageOpen, setIsImageOpen] = useState(false);
  const [currentImageSrc, setCurrentImageSrc] = useState('');

  const openImage = (imgSrc) => {
    setCurrentImageSrc(imgSrc);
    setIsImageOpen(true);
  };

  const closeImage = () => {
    setIsImageOpen(false);
    setCurrentImageSrc('');
  };

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <>
      <section className="bg-gray-800 rounded-lg overflow-hidden shadow-xl">
        <div className="p-4 md:p-6">
          <h3 className="text-2xl font-bold text-yellow-500 mb-4">
            Puntos de Interés
          </h3>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            {data.map(point => (
              <div key={point.id} className="bg-gray-700 p-4 rounded-lg shadow-lg">
                <img
                  src={point.imageUrl}
                  alt={point.name}
                  className="w-full h-32 object-cover rounded-lg cursor-pointer transform transition-transform duration-300 hover:scale-105"
                  onClick={() => openImage(point.imageUrl)}
                />
                <h4 className="text-xl font-semibold text-yellow-500 mt-2">
                  {point.name}
                </h4>
                <p className="mt-2 text-gray-300">
                  {point.description}
                </p>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* Modal para mostrar la imagen en grande */}
      {isImageOpen && (
        <div
          className="fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-50 transition-opacity duration-300 opacity-100"
          onClick={closeImage}
        >
          <div className="relative bg-gray-800 rounded-lg p-6">
            <button
              onClick={closeImage}
              className="absolute top-3 right-3 text-white text-3xl hover:text-yellow-400"
            >
              &times;
            </button>
            <img
              src={currentImageSrc}
              alt="Ampliación"
              className="w-full max-w-4xl h-auto rounded-lg"
            />
          </div>
        </div>
      )}
    </>
  );
};
