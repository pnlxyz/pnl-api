﻿using Application.Interfaces.Common;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Payloads;

namespace Application.Txns.Search;

public sealed record SearchTxnsQuery(TxnFilter Filter, TxnSort? Sort) : IQuery<IPaginatedList<Txn>>;

internal sealed class SearchTxnsQueryHandler(ITxnRepository txnRepository) : IQueryHandler<SearchTxnsQuery, IPaginatedList<Txn>>
{
  public async Task<Result<IPaginatedList<Txn>>> Handle(SearchTxnsQuery request, CancellationToken cancellationToken)
  {
    var txns = await txnRepository.Search(request.Filter, request.Sort);

    // TODO: exception handler ??
    // TODO: validation ??

    return Result.Create(txns);
  }
}