import { Link, useParams } from "react-router-dom";
import { useForm } from "react-hook-form";

function Purchases() {
  const { id } = useParams();

  const apiUrl = import.meta.env.VITE_Activites_API_URL;

  const { register, handleSubmit, formState: { errors }, reset } = useForm();

  const onSubmit = async (data) => {
    data.ActiviteId = id;
     console.log(apiUrl)
    console.log(id)

    const response = await fetch(apiUrl, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data)
    });
   

    const result = await response.json();

    if (response.ok) {
      alert("Purchase successful!");
      reset();
    } else {
      alert("Error: " + result.error);
    }
  };

  return (
    <div className="container my-5">

      <Link to={`/details/${id}`} className="btn btn-outline-secondary mb-3">Back to Details</Link>

      <h2>Buy a Ticket</h2>

      <form onSubmit={handleSubmit(onSubmit)} className="mt-4">

        <input type="hidden" {...register("ActiviteId")} value={id} />

        <div className="mb-3">
          <label className="form-label">Ticket Quantity</label>
          <input 
            type="number" className="form-control" {...register("tquantity", { required: true })}
          />
          {errors.tquantity && <p className="text-danger">{errors.tquantity.message}</p>}
        </div>

        <div className="mb-3">
          <label className="form-label">Email</label>
          <input 
            type="email" className="form-control" {...register("email", { required: true })}
          />
        </div>

        <div className="mb-3">
          <label className="form-label">Expiry (MM/YY)</label>
          <input 
            type="text" className="form-control"{...register("ccx", { required: true })}
          />
        </div>

        <div className="mb-3">
          <label className="form-label">CVC</label>
          <input 
            type="text" className="form-control" {...register("cvc", { required: true })}
          />
        </div>

        <button type="submit" className="btn btn-primary w-100">Submit</button>
      </form>
    </div>
  );
}

export default Purchases;
