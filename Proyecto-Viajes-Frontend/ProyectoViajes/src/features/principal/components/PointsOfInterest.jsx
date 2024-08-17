import { useState } from 'react';

export const PointsOfInterest = () => {
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

  return (
    <>
      <section className="bg-gray-800 rounded-lg overflow-hidden shadow-xl">
        <div className="p-4 md:p-6">
          <h3 className="text-2xl font-bold text-yellow-500 mb-4">
            Puntos de Interés
          </h3>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            
            {/* Punto de interés */}
            <div className="bg-gray-700 p-4 rounded-lg shadow-lg">
              <img
                src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
                alt="Museo del Louvre"
                className="w-full h-32 object-cover rounded-lg cursor-pointer transform transition-transform duration-300 hover:scale-105"
                onClick={() => openImage("https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg")}
              />
              <h4 className="text-xl font-semibold text-yellow-500 mt-2">
                Museo del Louvre
              </h4>
              <p className="mt-2 text-gray-300">
                El Museo del Louvre es uno de los museos más grandes y visitados del mundo. Alberga una vasta colección de arte, incluyendo la famosa pintura de la Mona Lisa.
              </p>
            </div>
            
            {/* Punto de interés */}
            <div className="bg-gray-700 p-4 rounded-lg shadow-lg">
              <img
                src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
                alt="Museo del Louvre"
                className="w-full h-32 object-cover rounded-lg cursor-pointer transform transition-transform duration-300 hover:scale-105"
                onClick={() => openImage("https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg")}
              />
              <h4 className="text-xl font-semibold text-yellow-500 mt-2">
                Museo del Louvre
              </h4>
              <p className="mt-2 text-gray-300">
                El Museo del Louvre es uno de los museos más grandes y visitados del mundo. Alberga una vasta colección de arte, incluyendo la famosa pintura de la Mona Lisa.
              </p>
            </div>
            
            {/* Punto de interés */}
            <div className="bg-gray-700 p-4 rounded-lg shadow-lg">
              <img
                src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
                alt="Museo del Louvre"
                className="w-full h-32 object-cover rounded-lg cursor-pointer transform transition-transform duration-300 hover:scale-105"
                onClick={() => openImage("https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg")}
              />
              <h4 className="text-xl font-semibold text-yellow-500 mt-2">
                Museo del Louvre
              </h4>
              <p className="mt-2 text-gray-300">
                El Museo del Louvre es uno de los museos más grandes y visitados del mundo. Alberga una vasta colección de arte, incluyendo la famosa pintura de la Mona Lisa.
              </p>
            </div>
          
          </div>
        </div>
      </section>

      {/* Para cuando se abra una imagen */}
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
