import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getDestinationDetails } from "../../../shared/actions/destinations/destinations";
import { PointsOfInterest } from "./PointsOfInterest";
import { DestinationDetailsSkeleton } from "./DestinationDetailsSkeleton"; 

export const DestinationDetails = () => {
  const { id } = useParams();
  const [destination, setDestination] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [isImageOpen, setIsImageOpen] = useState(false);

  useEffect(() => {
    const getDestination = async () => {
      setIsLoading(true);
      try {
        const response = await getDestinationDetails(id);
        setDestination(response.data);
      } catch (error) {
        console.error("Error fetching destination details:", error);
      } finally {
        setIsLoading(false);
      }
    };

    getDestination();
  }, [id]);

  const openImage = () => {
    setIsImageOpen(true);
  };

  const closeImage = () => {
    setIsImageOpen(false);
  };

  if (isLoading) {
    return <DestinationDetailsSkeleton />; // Mostrar el esqueleto durante la carga
  }

  return (
    <>
      <section className="bg-gray-800 rounded-lg overflow-hidden shadow-xl mb-8">
        <img
          src={destination.imageUrl}
          alt={destination.name}
          className="w-full h-64 object-cover cursor-pointer transform transition-transform duration-300 hover:scale-105"
          onClick={openImage}
        />
        <div className="p-4 md:p-6">
          <h2 className="text-3xl md:text-4xl font-bold text-yellow-500">
            {destination.name}
          </h2>
          <p className="mt-2 md:mt-3 text-gray-300">
            {destination.description}
          </p>
          <p className="mt-2 md:mt-3 text-gray-300">
            Ubicación: {destination.location}
          </p>
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
              src={destination.imageUrl}
              alt={destination.name}
              className="w-full max-w-4xl h-auto rounded-lg"
            />
          </div>
        </div>
      )}

      {/* Mostramos los puntos de interés para este destino */}
      <PointsOfInterest destinationId={destination.id} />
    </>
  );
};
