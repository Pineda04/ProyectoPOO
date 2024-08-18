import { useState } from "react";

export const ReservationsDetails = () => {
  const [reservations] = useState([
    { id: 1, name: "Reserva 1", date: "2024-08-20", status: "Confirmada" },
    { id: 2, name: "Reserva 2", date: "2024-09-10", status: "Pendiente" },
  ]);

  const [selectedReservation, setSelectedReservation] = useState(null);

  const handleReservationClick = (reservation) => {
    setSelectedReservation(reservation);
  };

  return (
    <main className="flex-1">
        <div className="container mx-auto px-4 py-8">
          <h1 className="text-3xl font-bold text-yellow-500 mb-6">Mis Reservas</h1>
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
            <div className="bg-gray-800 p-6 rounded-lg shadow-md">
              <h2 className="text-2xl font-semibold text-yellow-500 mb-4">Lista de Reservas</h2>
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
            </div>

            <div className="bg-gray-800 p-6 rounded-lg shadow-md">
              <h2 className="text-2xl font-semibold text-yellow-500 mb-4">Detalles de Reserva</h2>
              {selectedReservation ? (
                <>
                  <h3 className="text-lg font-semibold text-gray-300 mb-2">{selectedReservation.name}</h3>
                  <p className="text-gray-400">Fecha: {selectedReservation.date}</p>
                  <p className="text-gray-400">Estado: {selectedReservation.status}</p>
                  <p className="text-gray-300 mt-4">Detalles adicionales de la reserva...</p>
                </>
              ) : (
                <p className="text-gray-400">Selecciona una reserva para ver los detalles.</p>
              )}
            </div>
          </div>
        </div>
      </main>
  )
}
