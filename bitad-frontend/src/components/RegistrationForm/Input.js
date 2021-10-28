import styles from "./RegistrationFrom.module.css";

export function Input({
  name,
  errors,
  register,
  type,
  validate,
  minLength = { value: 3, message: "Minimum 3 znaki" },
  maxLength = { value: 50, message: "Maksymalnie 50 znaków" },
  pattern,
}) {
  const required = "Pole wymagane";

  return (
    <>
      <input
        type={type ? type : "text"}
        {...register(name, {
          required,
          minLength,
          maxLength,
          validate,
          pattern,
        })}
        className={`${styles.field__input} ${
          errors[name] !== undefined && styles["input--error"]
        }`}
      />
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </>
  );
}
