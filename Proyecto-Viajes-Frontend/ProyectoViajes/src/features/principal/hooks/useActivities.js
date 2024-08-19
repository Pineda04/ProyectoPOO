import { useEffect, useState } from 'react';
import axios from 'axios';

export const useActivities = (travelPackageId = null) => {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const getActivities = async () => {
      let allActivities = [];
      let page = 1;
      let hasMorePages = true;

      while (hasMorePages) {
        try {
          const response = await axios.get('https://localhost:7234/api/activities', {
            params: { page }
          });

          const activities = response.data.data.items;

          if (travelPackageId) {
            // Filtrar actividades por el travelPackageId
            const filteredActivities = activities.filter(activity => activity.travelPackageId === travelPackageId);
            allActivities = [...allActivities, ...filteredActivities];
          } else {
            allActivities = [...allActivities, ...activities];
          }

          if (activities.length === 0) {
            hasMorePages = false;
          } else {
            page += 1;
          }
        } catch (err) {
          setError(err.message);
          hasMorePages = false;
        }
      }

      setData(allActivities);
      setLoading(false);
    };

    getActivities();
  }, [travelPackageId]);

  return { data, loading, error };
};