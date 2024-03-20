﻿using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryVideo
    {
        Task<List<Video>> GetVideoList();
        Task<List<Video>> GetSortedTracksList();
        IQueryable<Video> GetSearchList(string name);
        Video GetTrack(int? id);
        void Update(Video v);
        Task Create(Video item);
        Task Delete(int id);
        Task Save();
    }
}
