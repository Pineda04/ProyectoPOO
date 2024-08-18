import { Link } from "react-router-dom";

export const DestinationsList = () => {
  return (
    <section className="py-12">
      <div className="container mx-auto px-4">
        <h2 className="text-3xl md:text-4xl font-bold text-center text-white mb-8">
          Destinos
        </h2>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-8">
          {/* Tarjeta de destino*/}
          <div className="bg-gray-700 rounded-lg overflow-hidden shadow-xl transform hover:scale-105 transition">
            <img
              src="https://www.viajarafrancia.com/wp-content/uploads/2009/05/museo-de-louvre-en-paris-760x500.jpg"
              alt="Destino 1"
              className="w-full h-48 sm:h-64 object-cover"
            />
            <div className="p-4 md:p-6">
              <h4 className="text-xl md:text-2xl font-semibold text-yellow-500">
                Destino
              </h4>
              <p className="mt-2 md:mt-3 text-gray-300">
                Descubre la belleza y la historia de este lugar fascinante.
              </p>
              <Link
                to="/destinations/destination/88c9aac3-75e4-4100-b4f0-a9388e4b6a3d"
                className="text-yellow-400 font-bold mt-3 md:mt-4 block hover:text-yellow-300 transition"
              >
                Ver más
              </Link>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};
