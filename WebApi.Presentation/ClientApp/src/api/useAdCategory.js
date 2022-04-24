import { useFetch } from "src/hooks/useFetch";
import { useGet } from "src/hooks/useGet";

export const useGetAdCategories = () => useGet("api/AdCategory");

// export const useAddAd = () => useFetch("api/Ad/", "POST");

// export const useGetAdDetail = (id) => useGet(`api/Ad/${id}`);

// export const usePutAd = (id) => useFetch(`api/Ad/${id}`, "PUT");

// export const useDeleteAd = () => useFetch("api/Ad", "DELETE");
