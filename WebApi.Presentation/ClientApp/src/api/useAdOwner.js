import { useFetch } from "src/hooks/useFetch";
import { useGet } from "src/hooks/useGet";

export const useGetAdOwnerDetail = (id) => useGet(`api/AdOwner/${id}`);

export const usePutAdOwner = (id) => useFetch(`api/AdOwner/${id}`, "PUT");
