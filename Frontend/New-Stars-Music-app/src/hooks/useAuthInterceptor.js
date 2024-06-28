import { useEffect } from "react";
import { setAuthInterceptor } from "../api/api";

export const useAuthInterceptor = ({ isLoading, getAccessTokenSilently }) => {
  useEffect(() => {
    if (!isLoading) {
      setAuthInterceptor(getAccessTokenSilently);
    }
  }, [isLoading]);
};
