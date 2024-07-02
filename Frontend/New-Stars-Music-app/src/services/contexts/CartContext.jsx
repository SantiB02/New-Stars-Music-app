import { createContext, useReducer } from "react";

export const CartContext = createContext();

const initialState = JSON.parse(window.localStorage.getItem("cart")) || [];

// update local storage when cart changes
export const updateLocalStorage = (state) => {
  window.localStorage.setItem("cart", JSON.stringify(state));
};

const reducer = (state, action) => {
  const { type: actionType, payload: actionPayload } = action;

  switch (actionType) {
    case "ADD_TO_CART":
      const { id } = actionPayload;
      const productInCartIndex = state.findIndex((item) => item.id === id);

      if (productInCartIndex >= 0) {
        const newState = structuredClone(state);
        updateLocalStorage(newState);
        return newState;
      }

      const newState = [...state, actionPayload];
      updateLocalStorage(newState);
      return newState;

    case "REMOVE_FROM_CART": {
      const newState = state.filter((item) => item.id !== actionPayload.id);
      updateLocalStorage(newState);
      return newState;
    }
    case "CLEAR_CART": {
      const initialState = [];
      updateLocalStorage([""]);
      return initialState;
    }
    default:
  }
};

export function CartProvider({ children }) {
  const [state, dispatch] = useReducer(reducer, initialState);

  const addToCart = (product) => {
    dispatch({ type: "ADD_TO_CART", payload: product });
  };

  const removeFromCart = (product) => {
    dispatch({ type: "REMOVE_FROM_CART", payload: product });
  };

  const clearCart = () => {
    dispatch({ type: "CLEAR_CART" });
  };

  return (
    <CartContext.Provider
      value={{
        cart: state,
        addToCart,
        clearCart,
        removeFromCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
}
