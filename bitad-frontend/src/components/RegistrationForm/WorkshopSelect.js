import { Select } from "./Select";
import { useState } from "react";
import { useGetRequest } from "../../hooks/http-requests";

export function WorkshopSelect({ name, errors, register }) {
  const [toggle, setToggle] = useState(false);

  const { response } = useGetRequest("/Workshop/GetWorkshops", toggle);

  const handleClick = () => {
    console.log("Clicked");
    setToggle((prevState) => !prevState);
  };

  const options = response.map((entry) => {
    const isDisabled = entry.maxParticipants <= entry.participantsNumber;
    return {
      label: entry.title,
      value: entry.workshopCode,
      disabled: isDisabled,
    };
  });

  return (
    <div onClick={handleClick}>
      <Select
        name={name}
        register={register}
        errors={errors}
        options={[{ value: null, label: "-" }, ...options]}
      />
    </div>
  );
}
