import styles from "./RegistrationFrom.module.css";

export function FieldInput({name, labelText, ...rest}) {
    return (
        <div className={styles.section__field}>
            <label htmlFor={name}>{labelText}</label>
            {rest.children}
        </div>
    );
}