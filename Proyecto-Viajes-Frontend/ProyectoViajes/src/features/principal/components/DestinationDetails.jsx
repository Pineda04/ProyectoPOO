import { useState } from 'react';

export const DestinationDetails = () => {
  const [isImageOpen, setIsImageOpen] = useState(false);

  const openImage = () => {
    setIsImageOpen(true);
  };

  const closeImage = () => {
    setIsImageOpen(false);
  };

  return (
    <>
      <section className="bg-gray-800 rounded-lg overflow-hidden shadow-xl mb-8  ">
        <img
          src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
          alt="Destino"
          className="w-full h-64 object-cover cursor-pointer transform transition-transform duration-300 hover:scale-105"
          onClick={openImage}
        />
        <div className="p-4 md:p-6">
          <h2 className="text-3xl md:text-4xl font-bold text-yellow-500">
            Torre Eiffel, París
          </h2>
          <p className="mt-2 md:mt-3 text-gray-300">
            La Torre Eiffel es un icónico monumento en París, Francia. Construida en 1889, ofrece vistas panorámicas de la ciudad y es uno de los destinos turísticos más famosos del mundo. La torre tiene una altura de 324 metros y está rodeada de hermosos jardines y áreas recreativas.
          </p>
          <p className="mt-2 md:mt-3 text-gray-300">
            Ubicación: Champ de Mars, 5 Avenue Anatole France, 75007 París, Francia
          </p>
        </div>
      </section>

      {/* Para cuando se abra la imagen */}
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
              src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
              alt="Destino"
              className="w-full max-w-4xl h-auto rounded-lg"
            />
          </div>
        </div>
      )}
    </>
  );
};
