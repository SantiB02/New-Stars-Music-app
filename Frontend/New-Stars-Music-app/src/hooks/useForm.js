export const useForm = () => {
  const validateForm = (form) => {
    let isValid = true;

    for (let value in form) {
      if (form[value] === null || form[value] === "") {
        isValid = false;
      }
    }

    return isValid;
  };

  return { validateForm };
};
