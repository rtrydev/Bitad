import styles from "./RegistrationFrom.module.css";

export function Input({name, errors, register, type, validate}) {
    const maxLength = {value: 50, message: "Maksymalnie 50 znaków"};
    const minLength = {value: 3, message: "Minimum 3 znaki"};
    const required = "Pole wymagane";
    return (
        <>
            <input
                type={type ? type : "text"}
                {...register(name, {required, minLength, maxLength, validate})}
                className={styles.field__input}
            />
            {errors[name] !== undefined && (
                <p className={styles.field__error}>{errors[name]?.message}</p>
            )}
        </>
    );
}