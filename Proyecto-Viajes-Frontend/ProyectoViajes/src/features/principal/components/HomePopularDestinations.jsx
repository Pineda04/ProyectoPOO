export const HomePopularDestinations = () => {
  return (
    <section className="py-12 md:py-20 bg-gray-800">
      <div className="container mx-auto px-4 md:px-6">
        <h3 className="text-3xl md:text-5xl font-bold text-center text-white mb-8 md:mb-12">
          Destinos Populares
        </h3>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {/* Tarjeta de destino */}
          <div className="bg-gray-700 rounded-lg overflow-hidden shadow-xl transform hover:scale-105 transition">
            <img
              src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
              alt="Destino 1"
              className="w-full h-48 sm:h-64 object-cover"
            />
            <div className="p-4 md:p-6">
              <h4 className="text-xl md:text-2xl font-semibold text-yellow-500">
                Destino 1
              </h4>
              <p className="mt-2 md:mt-3 text-gray-300">
                Descubre la belleza y la historia de este lugar fascinante.
              </p>
              <a
                href="#"
                className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
              >
                Ver más
              </a>
            </div>
          </div>
          {/* Tarjeta de destino */}
          <div className="bg-gray-700 rounded-lg overflow-hidden shadow-xl transform hover:scale-105 transition">
            <img
              src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
              alt="Destino 1"
              className="w-full h-48 sm:h-64 object-cover"
            />
            <div className="p-4 md:p-6">
              <h4 className="text-xl md:text-2xl font-semibold text-yellow-500">
                Destino 1
              </h4>
              <p className="mt-2 md:mt-3 text-gray-300">
                Descubre la belleza y la historia de este lugar fascinante.
              </p>
              <a
                href="#"
                className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
              >
                Ver más
              </a>
            </div>
          </div>
          {/* Tarjeta de destino */}
          <div className="bg-gray-700 rounded-lg overflow-hidden shadow-xl transform hover:scale-105 transition">
            <img
              src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
              alt="Destino 1"
              className="w-full h-48 sm:h-64 object-cover"
            />
            <div className="p-4 md:p-6">
              <h4 className="text-xl md:text-2xl font-semibold text-yellow-500">
                Destino 1
              </h4>
              <p className="mt-2 md:mt-3 text-gray-300">
                Descubre la belleza y la historia de este lugar fascinante.
              </p>
              <a
                href="#"
                className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
              >
                Ver más
              </a>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};
