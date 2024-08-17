import { useState } from "react";

export const TravelPackageDetails = () => {
  const [isImageOpen, setIsImageOpen] = useState(false);

  const openImage = () => {
    setIsImageOpen(true);
  };

  const closeImage = () => {
    setIsImageOpen(false);
  };

  return (
    <>
      <section className="pt-8 md:pt-12">
        <div className="container mx-auto px-4 md:px-6">
          <section className="bg-gray-800 rounded-lg overflow-hidden shadow-xl mb-8">
            <img
              src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
              alt="Paquete de Viaje"
              className="w-full h-64 object-cover cursor-pointer transform transition-transform duration-300 hover:scale-105"
              onClick={openImage}
            />
            <div className="p-4 md:p-6">
              <h2 className="text-3xl md:text-4xl font-bold text-yellow-500">
                Paquete a París
              </h2>
              <p className="mt-2 md:mt-3 text-gray-300">
                Explora la ciudad de la luz con este paquete exclusivo que
                incluye visitas a los principales puntos turísticos, alojamiento
                en hoteles de lujo y guías expertos para una experiencia
                inolvidable.
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Precio:</strong> $1,500
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Duración:</strong> 7 días
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Fecha de Inicio:</strong>{" "}
                2024-09-01
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Fecha de Fin:</strong>{" "}
                2024-09-08
              </p>
            </div>
          </section>

          {/* Pa cuando se cierre  */}
          {isImageOpen && (
            <div className="fixed inset-0 bg-black bg-opacity-70 flex items-center justify-center z-50">
              <div className="relative p-4 bg-gray-800 rounded-lg shadow-lg">
                <button
                  onClick={closeImage}
                  className="absolute top-2 right-2 text-gray-400 hover:text-gray-200"
                >
                  <svg
                    className="w-6 h-6"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth="2"
                      d="M6 18L18 6M6 6l12 12"
                    />
                  </svg>
                </button>
                <img
                  src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
                  alt="Imagen del Paquete"
                  className="max-w-full max-h-screen"
                />
              </div>
            </div>
          )}
        </div>
      </section>
    </>
  );
};
