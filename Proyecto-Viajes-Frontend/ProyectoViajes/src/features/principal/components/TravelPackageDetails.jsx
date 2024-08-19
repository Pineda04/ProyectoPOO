import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getTravelPackageDetails } from "../../../shared/actions/travelPakages/travelPackages";
import { formatDate } from "../../../shared/utils";
import { TravelPackageActivities } from "./TravelPackageActivities";

export const TravelPackageDetails = () => {
  const { id } = useParams();
  const [travelPackage, setTravelPackage] = useState(null);
  const [isImageOpen, setIsImageOpen] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    const getTravelPackage = async () => {
        const response = await getTravelPackageDetails(id);
        setTravelPackage(response.data);
      }

    getTravelPackage();
  }, [id]);

  const openImage = () => {
    setIsImageOpen(true);
  };

  const closeImage = () => {
    setIsImageOpen(false);
  };

  const handleReservation = () => {
    navigate('/reservations');
  };

  if (!travelPackage) {
    return (
      <div className="text-center text-white text-2xl py-12">
        Cargando detalles del paquete de viaje...
      </div>
    );
  }

  return (
    <>
      <section className="pt-8 md:pt-12">
        <div className="container mx-auto px-4 md:px-6">
          <section className="bg-gray-800 rounded-lg overflow-hidden shadow-xl mb-8">
            <img
              src={travelPackage.imageUrl}
              alt={travelPackage.name}
              className="w-full h-64 object-cover cursor-pointer transform transition-transform duration-300 hover:scale-105"
              onClick={openImage}
            />
            <div className="p-4 md:p-6">
              <h2 className="text-3xl md:text-4xl font-bold text-yellow-500">
                {travelPackage.name}
              </h2>
              <p className="mt-2 md:mt-3 text-gray-300">
                {travelPackage.description}
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Precio:</strong> ${travelPackage.price}
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Duración:</strong> {travelPackage.duration} días
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Fecha de Inicio:</strong> {formatDate(travelPackage.startDate)}
              </p>
              <p className="mt-2 md:mt-3 text-gray-300">
                <strong className="text-yellow-500">Fecha de Fin:</strong> {formatDate(travelPackage.endDate)}
              </p>
              {/* Botón de Reservar */}
              <button
                onClick={handleReservation}
                className="mt-6 w-full bg-yellow-500 text-gray-900 font-semibold py-2 rounded-lg hover:bg-yellow-600 transition-colors"
              >
                Reservar
              </button>
            </div>
          </section>

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
                  src={travelPackage.imageUrl}
                  alt={travelPackage.name}
                  className="max-w-full max-h-screen"
                />
              </div>
            </div>
          )}

          <TravelPackageActivities travelPackageId={travelPackage.id} />
        </div>
      </section>
    </>
  );
};
