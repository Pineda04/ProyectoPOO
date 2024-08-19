import { useState } from "react";

export const ReservationsDetails = () => {
  const [reservations, setReservations] = useState([
    { id: 1, name: "Reserva 1", date: "2024-08-20", status: "Confirmada", travelPackageId: 1 },
    { id: 2, name: "Reserva 2", date: "2024-09-10", status: "Pendiente", travelPackageId: 2 },
  ]);

  const [travelPackages] = useState([
    { id: 1, name: "Paquete 1", description: "Descripción del Paquete 1", price: "$1000", duration: "5 días", destination: "Destino 1", agency: "Agencia 1" },
    { id: 2, name: "Paquete 2", description: "Descripción del Paquete 2", price: "$2000", duration: "10 días", destination: "Destino 2", agency: "Agencia 2" },
  ]);

  const [selectedReservation, setSelectedReservation] = useState(null);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const getTravelPackage = (packageId) => {
    return travelPackages.find(pkg => pkg.id === packageId);
  };

  const handleReservationClick = (reservation) => {
    setSelectedReservation(reservation);
  };

  const handleCancel = () => {
    // Eliminar la reserva cancelada de la lista de reservas
    setReservations((prevReservations) =>
      prevReservations.filter((reservation) => reservation.id !== selectedReservation.id)
    );
    // Limpiar la reserva seleccionada
    setSelectedReservation(null);
  };

  const handlePay = () => {
    setIsModalOpen(true);
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  const handleSubmitPayment = (event) => {
    event.preventDefault();

    // Actualizar el estado de la reserva seleccionada a Confirmada
    setReservations((prevReservations) => 
      prevReservations.map((reservation) => 
        reservation.id === selectedReservation.id 
          ? { ...reservation, status: "Confirmada" } 
          : reservation
      )
    );

    setSelectedReservation(null);
    
    handleCloseModal();

  };

  return (
    <main className="flex-1">
      <div className="container mx-auto px-4 py-8">
        <h1 className="text-3xl font-bold text-yellow-500 mb-6">Mis Reservas</h1>
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
          <div className="bg-gray-800 p-6 rounded-lg shadow-md">
            <h2 className="text-2xl font-semibold text-yellow-500 mb-4">Lista de Reservas</h2>
            {reservations.length > 0 ? (
              <ul>
                {reservations.map((reservation) => (
                  <li
                    key={reservation.id}
                    className="mb-4 p-4 border border-gray-600 rounded-lg hover:bg-gray-700 cursor-pointer"
                    onClick={() => handleReservationClick(reservation)}
                  >
                    <h3 className="text-lg font-semibold text-gray-300">{reservation.name}</h3>
                    <p className="text-gray-400">Fecha: {reservation.date}</p>
                    <p className="text-gray-400">Estado: {reservation.status}</p>
                  </li>
                ))}
              </ul>
            ) : (
              <p className="text-gray-400">No se encontraron reservas.</p>
            )}
          </div>

          <div className="bg-gray-800 p-6 rounded-lg shadow-md">
            <h2 className="text-2xl font-semibold text-yellow-500 mb-4">Detalles de Reserva</h2>
            {selectedReservation ? (
              <>
                <h3 className="text-lg font-semibold text-gray-300 mb-2">{selectedReservation.name}</h3>
                <p className="text-gray-400">Fecha: {selectedReservation.date}</p>
                <p className="text-gray-400">Estado: {selectedReservation.status}</p>
                <div className="mt-4">
                  <h3 className="text-lg font-semibold text-gray-300 mb-2">Información del Paquete de Viaje</h3>
                  {getTravelPackage(selectedReservation.travelPackageId) ? (
                    <>
                      <p className="text-gray-400">Nombre: {getTravelPackage(selectedReservation.travelPackageId).name}</p>
                      <p className="text-gray-400">Descripción: {getTravelPackage(selectedReservation.travelPackageId).description}</p>
                      <p className="text-gray-400">Destino: {getTravelPackage(selectedReservation.travelPackageId).destination}</p>
                      <p className="text-gray-400">Agencia: {getTravelPackage(selectedReservation.travelPackageId).agency}</p>
                      <p className="text-gray-400">Precio: {getTravelPackage(selectedReservation.travelPackageId).price}</p>
                      <p className="text-gray-400">Duración: {getTravelPackage(selectedReservation.travelPackageId).duration}</p>
                    </>
                  ) : (
                    <p className="text-gray-400">Información del paquete de viaje no disponible.</p>
                  )}
                </div>
                <div className="mt-6 flex space-x-4">
                  {selectedReservation.status === "Confirmada" ? (
                    <button
                      onClick={handleCancel}
                      className="bg-red-500 text-white font-semibold py-2 px-4 rounded-lg hover:bg-red-600 transition-colors"
                    >
                      Cancelar
                    </button>
                  ) : (
                    <>
                      <button
                        onClick={handlePay}
                        className="bg-green-500 text-white font-semibold py-2 px-4 rounded-lg hover:bg-green-600 transition-colors"
                      >
                        Pagar
                      </button>
                      <button
                        onClick={handleCancel}
                        className="bg-red-500 text-white font-semibold py-2 px-4 rounded-lg hover:bg-red-600 transition-colors"
                      >
                        Cancelar
                      </button>
                    </>
                  )}
                </div>
              </>
            ) : (
              <p className="text-gray-400">Sin detalles.</p>
            )}
          </div>
        </div>
      </div>

      {/* Modal de Pago */}
      {isModalOpen && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
          <div className="bg-gray-800 p-6 rounded-lg w-full max-w-md">
            <h2 className="text-2xl font-semibold text-yellow-500 mb-4">Formulario de Pago</h2>
            <form onSubmit={handleSubmitPayment}>
              <div className="mb-4">
                <label htmlFor="cardNumber" className="block text-gray-300 mb-2">Número de Tarjeta</label>
                <input
                  id="cardNumber"
                  type="text"
                  className="w-full p-2 bg-gray-700 text-gray-300 rounded-lg"
                  required
                />
              </div>
              <div className="mb-4">
                <label htmlFor="expirationDate" className="block text-gray-300 mb-2">Fecha de Expiración</label>
                <input
                  id="expirationDate"
                  type="text"
                  className="w-full p-2 bg-gray-700 text-gray-300 rounded-lg"
                  required
                />
              </div>
              <div className="mb-4">
                <label htmlFor="cvv" className="block text-gray-300 mb-2">CVV</label>
                <input
                  id="cvv"
                  type="text"
                  className="w-full p-2 bg-gray-700 text-gray-300 rounded-lg"
                  required
                />
              </div>
              <div className="flex justify-end space-x-4">
                <button
                  type="button"
                  onClick={handleCloseModal}
                  className="bg-red-500 text-white font-semibold py-2 px-4 rounded-lg hover:bg-red-600 transition-colors"
                >
                  Cancelar
                </button>
                <button
                  type="submit"
                  className="bg-green-500 text-white font-semibold py-2 px-4 rounded-lg hover:bg-green-600 transition-colors"
                >
                  Pagar
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </main>
  );
};
